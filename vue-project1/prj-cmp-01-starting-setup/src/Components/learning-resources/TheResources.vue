<template>
  <base-card>
    <base-button
      @click="setSelectedTab('stored-resources')"
      :mode="storedRestButtionMode"
      >Stored Resources</base-button
    >
    <base-button
      @click="setSelectedTab('add-resources')"
      :mode="addResButtionMode"
      >Add Resources</base-button
    >
  </base-card>
  <keep-alive>
    <component :is="selectedTab"></component>
  </keep-alive>
</template>

<script>
import StoredResources from './StoredResources.vue';
import AddResources from './AddResources.vue';
export default {
  components: {
    StoredResources,
    AddResources,
  },
  data() {
    return {
      selectedTab: 'stored-resources',
      storedResources: [
        {
          id: 'official-guide',
          title: 'Official Guide',
          descripton: 'The official vue.js documentation.',
          link: 'https://vuejs.org',
        },
        {
          id: 'google',
          title: 'Google',
          descripton: 'learn to google documentation.',
          link: 'https://google.org',
        },
      ],
    };
  },
  computed: {
    storedRestButtionMode() {
      return this.selectedTab === 'stored-resources' ? null : 'flat';
    },
    addResButtionMode() {
      return this.selectedTab === 'add-resources' ? null : 'flat';
    },
  },
  provide() {
    return {
      resources: this.storedResources,
      addResource: this.addResource,
      removeResource: this.removeResource
    };
  },
  methods: {
    setSelectedTab(tab) {
      this.selectedTab = tab;
    },
    addResource(title, descripton, link) {
      const newResource = {
        id: new Date().toISOString(),
        title,
        descripton,
        link,
      };
      this.storedResources.unshift(newResource);
      this.selectedTab = 'stored-resources';
    },
    removeResource(resourceId) {
      const resIndex = this.storedResources.findIndex(res => res.id == resourceId);
      this.storedResources.splice(resIndex, 1);
      console.log(this.storedResources.length)
    },
  },
};
</script>

<style scoped></style>
