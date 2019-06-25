<template>
  <div class="myContainer">
    <slideshow
      :images="`assets/socialPrograms/images/${this.getCurrentProgram.imageLarge}`"
      :imageMobile="`assets/socialPrograms/mobile/${this.getCurrentProgram.imageMobile}`"
    />
    <div class="container">
      <div class="row back">
        <div class="col">
          <router-link class="btn btn-outline-primary" :to="{ name: 'programOverview' }">Program</router-link>
        </div>
      </div>
      <h1
        class="title"
      >{{ language === 'de' ? this.getCurrentProgram.nameDe : this.getCurrentProgram.nameFr }}</h1>

      <div class="row">
        <div class="col-12 text-content" v-html="description"></div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import { mapGetters, mapActions } from 'vuex'

import Slideshow from 'components/partials/Slideshow'
export default {
  metaInfo() {
    return {
      title: `| ${
        this.language === 'de' ? this.getCurrentProgram.nameDe : this.getCurrentProgram.nameFr
      }`
    }
  },

  components: {
    Slideshow
  },

  methods: {
    ...mapActions('program', ['loadCurrentProgram'])
  },

  mounted() {
    this.loadCurrentProgram(this.$route.params.id)
  },

  computed: {
    ...mapGetters('program', ['getCurrentProgram']),
    ...mapGetters(['language']),

    description() {
      return this.language === 'de'
        ? this.getCurrentProgram.descriptionDe
        : this.getCurrentProgram.descriptionFr
    }
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
