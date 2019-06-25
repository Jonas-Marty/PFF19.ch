<template>
  <transition name="bounce">
    <nav
      class="navbar navbar-expand-md navbar-inverse position-fixed shadow-sm"
      :class="{ embedded: embedded && isHome && !collapse }"
    >
      <router-link class="navbar-brand" :to="{ name: 'home' }">
        <img
          :class="{}"
          src="../../assets/images/black_green_small_logo.png"
          height="40"
          class="d-inline-block align-top"
          alt="logo_pff19"
        />
      </router-link>

      <div class="mr-auto nav-link">
        <a class="nav-item language" @click="changeLang('de')">de</a>
        <span class="nav-item">|</span>
        <a class="nav-item language" @click="changeLang('fr')">fr</a>
      </div>

      <button
        class="navbar-toggler"
        @click="collapse = !collapse"
        type="button"
        data-toggle="collapse"
        data-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="fa fa-navicon"></span>
      </button>

      <div class="collapse navbar-collapse" :class="{ show: collapse }" id="navbarNavAltMarkup">
        <div class="navbar-nav ml-auto">
          <span
            class="nav-item"
            :class="{ dropdown: route.children }"
            v-for="route in getDefaultRoutes"
            :key="route.name"
          >
            <router-link
              v-if="route.important && !route.children"
              :to="route.path"
              class="nav-link"
              >{{ $t(`lang.navigation.${route.name}`) }}</router-link
            >

            <div
              v-if="route.children"
              class="nav-link dropdown-toggle"
              id="navbarDropdown"
              role="button"
              @click="openDropdown(route.name)"
              aria-haspopup="true"
              aria-expanded="false"
            >
              {{ $t(`lang.navigation.${route.name}`) }}
            </div>
            <div
              v-if="route.children"
              class="dropdown-menu shadow-sm"
              :class="{ show: dropdown[route.name] }"
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
import i18n from '../../locales'
import { mapActions } from 'vuex'

export default {
  data() {
    return {
      routes,
      embedded: true,
      collapse: false,
      dropdown: { info: false, programm: false }
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
  methods: {
    ...mapActions(['switchI18n']),

    toggleCollapsed(event) {
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
        this.dropdown.programm = false
      } else {
        this.dropdown.info = false
        this.dropdown.programm = !this.dropdown.programm
      }
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
        console.log(self.dropdown)
        self.dropdown.info = false
        self.dropdown.programm = false
      }
    })
  },

  destroyed() {
    window.removeEventListener('scroll', this.navbarBackgroundController)
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
