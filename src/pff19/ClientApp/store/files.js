import auth from 'utils/auth'

export const files = {
  namespaced: true,
  state: {
    files: []
  },

  getters: {
    all: state => {
      return state.files
    }
  },

  mutations: {
    load: (state, payload) => {
      state.files = payload
    },

    remove: (state, other) => {
      state.files = state.files.filter(el => el != other)
    }
  },

  actions: {
    load: ({ commit }) => {
      auth
        .get('/file')
        .then(response => {
          commit('load', response.data)
        })
        .catch(() => {})
    },

    remove: ({ commit }, payload) => {
      auth
        .delete(`/file/${payload}`)
        .then(() => {
          commit('remove', payload)
        })
        .catch(() => {})
    }
  }
}
