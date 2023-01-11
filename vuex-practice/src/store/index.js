import { createStore } from 'vuex';
import { productStore } from './modules/products';
import { cartStore } from './modules/cart';

export const store = createStore({
  modules: {
    products: productStore,
    cart: cartStore,
  },
  state() {
    return {
      isLoggedIn: false,
    };
  },
  mutations: {
    logina(state,payload) {
      state.isLoggedIn = payload.isAuth;
    },
    logouta(state,payload) {
      state.isLoggedIn = payload.isAuth;
    },
  },
  actions: {
    login(context) {
        context.commit('logina',{isAuth:true})
      },
      logout(context) {
        context.commit('logouta',{isAuth:false})
      },
  },
  getters: {
    isAuth(state){
        return state.isLoggedIn;
    }
  },
});
