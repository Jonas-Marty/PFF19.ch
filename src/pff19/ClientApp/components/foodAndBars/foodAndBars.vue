<template>
  <div class="myContainer">
    <slideshow
      :images="`assets/bars/images/${getCurrentBar.imageLarge}`"
      :imageMobile="`assets/bars/mobile/${getCurrentBar.imageMobile}`"
    />
    <div class="container">
      <div class="row back">
        <div class="col">
          <router-link :to="{ name: 'foodAndBarsOverview' }" class="btn btn-outline-primary"
            >All Food&Bars</router-link
          >
        </div>
      </div>
      <h1 class="title">
        {{ language === 'de' ? getCurrentBar.nameDe : getCurrentBar.nameFr }}
      </h1>

      <div class="row">
        <div v-html="description" class="col-12 text-content"></div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

import Slideshow from 'components/partials/Slideshow'
export default {
  metaInfo() {
    return {
      title: `| ${this.language === 'de' ? this.getCurrentBar.nameDe : this.getCurrentBar.nameFr}`
    }
  },

  components: {
    Slideshow
  },
  data() {
    return {
      bars: {}
    }
  },

  computed: {
    ...mapGetters('bars', ['getCurrentBar']),
    ...mapGetters(['language']),

    description() {
      return this.language === 'de'
        ? this.getCurrentBar.descriptionDe
        : this.getCurrentBar.descriptionFr
    }
  },

  mounted() {
    this.loadCurrentBar(this.$route.params.id)
  },

  methods: {
    ...mapActions('bars', ['loadCurrentBar'])
  }
}
</script>

<style lang="scss" scoped>
h1 {
  margin-bottom: 20px;
}

.date {
  margin-bottom: 30px;
}

.back {
  margin-bottom: 30px;
}

.title {
  margin-bottom: 40px;
  margin-right: 20px;
  display: inline-block;
}

.title-playtime {
  display: inline-block;
}

.bar-image {
  max-height: 100%;
  max-width: 100%;
}

.myContainer {
  padding-top: 40;
}
.container {
  margin-top: 30px;
}

@media (max-width: 768px) {
  .text-content {
    margin-bottom: 20px;
  }
  .slideshow {
    height: 320px;
  }
}
</style>
