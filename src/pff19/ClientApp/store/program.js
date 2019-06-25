import axios from 'axios'
import auth from '../auth'

export const program = {
  namespaced: true,
  state: {
    programs: [],
    currentProgram: {}
  },

  getters: {
    all: state => {
      return state.programs.sort((a, b) => a.order - b.order)
    },

    getCurrentProgram: state => {
      return state.currentProgram
    }
  },

  mutations: {
    load: (state, payload) => {
      state.programs = payload
    },

    loadCurrentProgram: (state, payload) => {
      state.currentProgram = payload
    },

    remove: (state, id) => {
      state.programs = state.programs.filter(el => el.id !== id)
    }
  },

  actions: {
    load: ({commit}) => {
      axios.get('/api/socialprograms')
        .then(response => {
          commit('load', response.data)
        }).catch(e => {
        })
    },

    loadCurrentProgram: ({commit}, payload) => {
      axios.get(`/api/socialprograms/${payload}`)
        .then(response => {
          commit('loadCurrentProgram', response.data)
        }).catch(e => {
        })
    },

    remove: ({commit}, payload) => {
      auth.delete(`/socialprograms/${payload}`)
        .then(response => {
          commit('remove', payload)
        }).catch(e => {
        })
    },
    swap: ({ commit }, { first, second }) => {
      auth.put(`/socialprograms/${first}/${second}`)
    }
  }
}
