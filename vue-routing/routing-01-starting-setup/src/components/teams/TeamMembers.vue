<template>
  <section>
    <h2>{{ teamName }}</h2>
    <ul>
      <user-item
        v-for="member in members"
        :key="member.id"
        :name="member.fullName"
        :role="member.role"
      ></user-item>
    </ul>
    <router-link to="/teams/t2">Go to the team 2</router-link>
  </section>
</template>

<script>
import UserItem from '../users/UserItem.vue';

export default {
  components: {
    UserItem
  },
  inject:['users','teams'],
  data() {
    return {
      teamName:'',
      members:[]
    };
  },
  methods:{
    loadTeamMembers(route){
      const teamId = route.params.teamId
    // console.log(this.$route.params.teamId)

    const selectedTeam = this.teams.find(team => team.id == teamId);
    const members = selectedTeam.members
    const selectedMember = []
    for(const member of members) {
      const selectedUser = this.users.find(user => user.id == member);
      selectedMember.push(selectedUser)
    }
    this.members = selectedMember
    this.teamName = selectedTeam.name
    }
  },
  created(){
    this.loadTeamMembers(this.$route);
    console.log(this.$route.query)
  },
  watch:{
    $route(newRoute){
      this.loadTeamMembers(newRoute)
    }
  }
};
</script>

<style scoped>
section {
  margin: 2rem auto;
  max-width: 40rem;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.26);
  padding: 1rem;
  border-radius: 12px;
}

h2 {
  margin: 0.5rem 0;
}

ul {
  list-style: none;
  margin: 0;
  padding: 0;
}
</style>