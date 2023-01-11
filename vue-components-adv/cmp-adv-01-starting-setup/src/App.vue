<template>
  <div>
    <!-- <the-header></the-header> -->
    <TheHeader />
    <!-- <BadgeList/>
    <UserInfo
      :full-name="activeUser.name"
      :info-text="activeUser.description"
      :role="activeUser.role"
    /> -->
    <button @click="setSelectedComponent('active-goals')">Active Goals</button>
    <button @click="setSelectedComponent('manage-goals')">Manage Goals</button>

    <!-- <active-goals v-if="selectedComponent === 'active-goals'"></active-goals>
    <manage-goals v-if="selectedComponent === 'manage-goals'"></manage-goals> -->

    <keep-alive>
      <component :is="selectedComponent">
      </component>
    </keep-alive>
  </div>
</template>

<script>
import TheHeader from "./components/TheHeader.vue";
// import UserInfo from "./components/UserInfo.vue";
// import BadgeList from "./components/BadgeList.vue";
import ManageGoals from "./components/ManageGoals.vue";
import ActiveGoals from "./components/ActiveGoals.vue";
export default {
  components: {
    TheHeader,
    // UserInfo,
    // BadgeList,
    ManageGoals,
    ActiveGoals,
  },
  data() {
    return {
      selectedComponent: "active-goals",
      activeUser: {
        name: "Maximilian Schwarzmüller",
        description: "Site owner and admin",
        role: "admin",
      },
    };
  },
  methods: {
    setSelectedComponent(comp) {
      console.log(comp)
      this.selectedComponent = comp
    }
  }
};
</script>

<style>
html {
  font-family: sans-serif;
}

body {
  margin: 0;
}
</style>
