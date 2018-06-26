import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export const store = new Vuex.Store({
    state: {
        isHome: false
    },

    getters: {
        isHome: state => {
            return state.isHome;
        }
    },

    mutations: {
        enterHome: state => {
            state.isHome = true;
        },
        leaveHome: state => {
            state.isHome = false;
        }
    },

    actions: {
        enterHome: ({commit}) => {
            commit('enterHome');
        },
        leaveHome: ({commit}) => {
            commit('leaveHome');
        }
    }
});
