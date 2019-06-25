import auth from 'utils/auth'

export const helfer = {
  namespaced: true,
  state: {
    helfer: []
  },

  getters: {
    all: state => {
      return state.helfer
    },
    get: state => {
      return id => state.helfer.find(elem => {
        return elem.id === id
      })
    }
  },

  mutations: {
    load: (state, payload) => {
      state.helfer = payload
    },

    remove: (state, id) => {
      state.helfer = state.helfer.filter(el => el.id !== id)
    }
  },

  actions: {
    load: ({commit}) => {
      auth.get('Assistants')
        .then(response => {
          commit('load', response.data)
        }).catch(e => console.log(e))
    },

    remove: ({commit}, payload) => {
      auth.delete(`/Assistants/${payload}`)
        .then(response => {
          commit('remove', payload)
        }).catch(e => console.log(e))
    }
  }
}
