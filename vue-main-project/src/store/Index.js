import { createStore } from 'vuex';
import coachesModule from './modules/coaches/index.js';
import requests from './modules/requests/index.js'

export const store = createStore({
  modules: {
    coaches: coachesModule,
    requests:requests,
  },
  state(){
    return{
      userId:'c3'
    }
  },
  getters: {
    userId(state){
      return state.userId
    }
  }
});
