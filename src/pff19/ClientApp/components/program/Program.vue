<template>
  <div class="myContainer">
    <slideshow
      :images="`assets/socialPrograms/images/${getCurrentProgram.imageLarge}`"
      :imageMobile="`assets/socialPrograms/mobile/${getCurrentProgram.imageMobile}`"
    />
    <div class="container">
      <div class="row back">
        <div class="col">
          <router-link :to="{ name: 'programOverview' }" class="btn btn-outline-primary"
            >Program</router-link
          >
        </div>
      </div>
      <h1 class="title">
        {{ language === 'de' ? getCurrentProgram.nameDe : getCurrentProgram.nameFr }}
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
      title: `| ${
        this.language === 'de' ? this.getCurrentProgram.nameDe : this.getCurrentProgram.nameFr
      }`
    }
  },

  components: {
    Slideshow
  },
  computed: {
    ...mapGetters('program', ['getCurrentProgram']),
    ...mapGetters(['language']),

    description() {
      return this.language === 'de'
        ? this.getCurrentProgram.descriptionDe
        : this.getCurrentProgram.descriptionFr
    }
  },

  mounted() {
    this.loadCurrentProgram(this.$route.params.id)
  },

  methods: {
    ...mapActions('program', ['loadCurrentProgram'])
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
