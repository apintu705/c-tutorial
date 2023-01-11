<template>
  <button v-if="!userIsAuthenticated" @click="login">Login</button>
  <button v-if="userIsAuthenticated" @click="logout">Logout</button>
</template>

<script>
import { mapActions } from 'vuex';
import { mapGetters } from 'vuex';
export default{
    methods:{
        ...mapActions(['login','logout'])
    },
    computed:{
        ...mapGetters(['userIsAuthenticated'])
    }
}
</script>