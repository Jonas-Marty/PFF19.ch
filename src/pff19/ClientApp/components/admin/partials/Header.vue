<template>
  <transition name="bounce">
    <nav class="navbar navbar-expand-md navbar-inverse position-fixed shadow-sm">
      <router-link :to="{ name: 'adminDashboard' }" class="navbar-brand">
        <img
          :class="{}"
          src="../../../assets/images/black_red_small_logo.png"
          height="40"
          class="d-inline-block align-top"
          alt="logo_pff19"
        />
      </router-link>

      <button
        @click="collapse = !collapse"
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="fa fa-navicon"></span>
      </button>

      <div id="navbarNavAltMarkup" :class="{ show: collapse }" class="collapse navbar-collapse">
        <div class="navbar-nav ml-auto">
          <router-link
            v-for="route in getAdminRoutes"
            :key="route.display"
            v-if="route.important"
            :to="{ name: route.name }"
            class="nav-item nav-link"
          >
            {{ route.display }}
          </router-link>
          <a @click="logout" href="/admin/login" class="nav-item nav-link">
            Log out
          </a>
        </div>
      </div>
    </nav>
  </transition>
</template>

<script>
import { routes } from '../../../routes'
import { mapActions } from 'vuex'

export default {
  data() {
    return {
      routes,
      collapse: false
    }
  },

  computed: {
    getAdminRoutes() {
      return routes.find(route => route.name === 'admin').children
    },
    isHome() {
      return this.$store.getters.isHome
    }
  },

  created() {
    let self = this

    window.addEventListener('click', function(e) {
      // close dropdown when clicked outside
      if (
        !self.$el.contains(e.target) ||
        (self.$el.contains(e.target) && e.target.tagName === 'A')
      ) {
        self.collapse = false
      }
    })
  },

  methods: {
    ...mapActions('api', ['logout']),

    toggleCollapsed() {
      this.collapsed = !this.collapsed
    }
  }
}
</script>

<style lang="scss" scoped>
.navbar {
  color: black;
  background: white;
  width: 100%;
  z-index: 999;
  font-family: 'Glacial Indifference Bold';
  text-transform: uppercase;
  position: absolute;
}

.navbar,
.shadow-sm {
  transition: all 0.5s ease;
  -webkit-transition: all 0.5s ease;
  -moz-transition: all 0.5s ease;
  -o-transition: all 0.5s ease;
}
</style>
