<template>
  <transition name="bounce">
    <nav
      :class="{ embedded: embedded && isHome && !collapse }"
      class="navbar navbar-expand-md navbar-inverse position-fixed shadow-sm"
    >
      <router-link :to="{ name: 'home' }" class="navbar-brand">
        <img
          :class="{}"
          src="../../assets/images/black_green_small_logo.png"
          height="40"
          class="d-inline-block align-top"
          alt="logo_pff19"
        />
      </router-link>

      <div class="mr-auto nav-link">
        <a @click="changeLang('de')" class="nav-item language">de</a>
        <span class="nav-item">|</span>
        <a @click="changeLang('fr')" class="nav-item language">fr</a>
      </div>

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
          <span
            :class="{ dropdown: route.children }"
            v-for="route in getDefaultRoutes"
            :key="route.name"
            class="nav-item"
          >
            <router-link
              v-if="route.important && !route.children"
              :to="route.path"
              class="nav-link"
              >{{ $t(`lang.navigation.${route.name}`) }}</router-link
            >

            <div
              id="navbarDropdown"
              v-if="route.children"
              @click="openDropdown(route.name)"
              class="nav-link dropdown-toggle"
              role="button"
              aria-haspopup="true"
              aria-expanded="false"
            >
              {{ $t(`lang.navigation.${route.name}`) }}
            </div>
            <div
              v-if="route.children"
              :class="{ show: dropdown[route.name] }"
              class="dropdown-menu shadow-sm"
              aria-labelledby="navbarDropdown"
            >
              <router-link
                v-for="child in route.children"
                :key="child.name"
                :to="{ name: child.name }"
                class="nav-link"
                >{{ $t(`lang.navigation.${child.name}`) }}</router-link
              >
            </div>
          </span>
        </div>
      </div>
    </nav>
  </transition>
</template>

<script>
import { routes } from '../../routes'
import { mapActions } from 'vuex'

export default {
  data() {
    return {
      routes,
      embedded: true,
      collapse: false,
      dropdown: { info: false, program: false }
    }
  },

  computed: {
    isHome() {
      return this.$store.getters.isHome
    },

    getDefaultRoutes() {
      return this.routes.find(route => route.name === 'default').children
    }
  },

  created() {
    window.addEventListener('scroll', this.navbarBackgroundController)

    let self = this

    window.addEventListener('click', function(e) {
      // close dropdown when clicked outside
      if (
        !self.$el.contains(e.target) ||
        (self.$el.contains(e.target) && e.target.tagName === 'A')
      ) {
        self.collapse = false
        self.dropdown.info = false
        self.dropdown.program = false
      }
    })
  },

  destroyed() {
    window.removeEventListener('scroll', this.navbarBackgroundController)
  },

  methods: {
    ...mapActions(['switchI18n']),

    toggleCollapsed() {
      this.collapsed = !this.collapsed
    },
    navbarBackgroundController() {
      if (window.scrollY > 0) {
        this.embedded = false
      } else {
        this.embedded = true
      }
    },
    changeLang(lang) {
      if (this.$store.getters.language !== lang) {
        this.switchI18n(lang)
      }
    },
    openDropdown(self) {
      if (self === 'info') {
        this.dropdown.info = !this.dropdown.info
        this.dropdown.program = false
      } else {
        this.dropdown.info = false
        this.dropdown.program = !this.dropdown.program
      }
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
}

.navbar,
.shadow-sm {
  transition: all 0.5s ease;
  -webkit-transition: all 0.5s ease;
  -moz-transition: all 0.5s ease;
  -o-transition: all 0.5s ease;
}

.navbar .shadow-sm {
  transition: none;
  -webkit-transition: none;
  -moz-transition: none;
  -o-transition: none;
}

.embedded {
  color: white;
  background: none;
  box-shadow: none !important;
}

.embedded .navbar-brand {
  visibility: hidden;
}

.embedded .nav-link {
  color: white;
}

.embedded .dropdown-menu .nav-link {
  color: #007bff;
}

.language {
  cursor: pointer;
}

.embedded .navbar-toggler {
  color: white;
}

.nav-link {
  color: #007bff;
}

.dropdown-menu {
  border: none;
  padding: 8px;
}

.dropdown-toggle {
  cursor: pointer;
}

@media (max-width: 768px) {
  .dropdown-menu {
    background-color: #ececec;
    padding-left: 20px;
  }
  .navbar .shadow-sm {
    box-shadow: none !important;
  }
}
</style>
