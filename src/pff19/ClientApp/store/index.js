import Vue from 'vue'
import Vuex from 'vuex'
import i18n from '../locales'
import { news } from './news'
import { api } from './api'
import { sponsors } from './sponsors'

Vue.use(Vuex)

export const store = new Vuex.Store({
  state: {
    isHome: false,
    language: window.localStorage.getItem('language') || ''
  },

  getters: {
    isHome: state => {
      return state.isHome
    },
    language: state => {
      return state.language
    }
  },

  mutations: {
    enterHome: state => {
      state.isHome = true
    },
    leaveHome: state => {
      state.isHome = false
    },
    changeLang: (state, data) => {
      i18n.locale = data
      state.language = data
      window.localStorage.setItem('language', data)
    }

  },

  actions: {
    enterHome: ({commit}) => {
      commit('enterHome')
    },
    leaveHome: ({commit}) => {
      commit('leaveHome')
    },
    switchI18n ({ commit }, context) {
      commit('changeLang', context)
    }

  },

  modules: {
    news,
    api,
    sponsors
  }
})
