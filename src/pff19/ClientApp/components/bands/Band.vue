<template>
  <div class="myContainer">
    <slideshow
      :images="`assets/bands/images/${getCurrentBand.imageLarge}`"
      :image-mobile="`assets/bands/mobile/${getCurrentBand.imageMobile}`"
    />
    <div class="container">
      <div class="row back">
        <div class="col">
          <router-link :to="{ name: 'bandsOverview' }" class="btn btn-outline-primary">Alle Bands</router-link>
        </div>
      </div>
      <h1 class="title">{{ getCurrentBand.name }}</h1>
      <h6 class="title-playtime" v-if="getCurrentBand.playTimeForSorting">
        {{ getCurrentBand.playTimeForSorting | formateDateTime(language) }}
        {{ getCurrentBand.stage ? `| ${getCurrentBand.stage}` : '' }}
      </h6>

      <div v-if="getCurrentBand.spotifyPlaylist" class="row">
        <div v-html="description" class="col-12 col-md-6 text-content" />
        <div class="col-12 col-md-6">
          <iframe
            :src="getCurrentBand.spotifyPlaylist"
            class="spotify"
            frameborder="0"
            allowtransparency="true"
            allow="encrypted-media"
          />
        </div>
      </div>

      <div v-else class="row">
        <div v-html="description" class="col-12 text-content" />
      </div>

      <div v-if="getCurrentBand.webSiteUrl" class="row">
        <div class="col-12 band-website">
          <a :href="getCurrentBand.webSiteUrl">Band Website</a>
        </div>
      </div>

      <div v-if="getCurrentBand.facebook || getCurrentBand.instagram" class="row">
        <div class="col-12 social-media-container">
          <div v-if="getCurrentBand.facebook" class="social-media">
            <a :href="getCurrentBand.facebook">
              <img :src="require('assets/images/facebook.png')" alt="facebook" class="social-icon" />
            </a>
          </div>
          <div v-if="getCurrentBand.instagram" class="social-media">
            <a :href="getCurrentBand.instagram">
              <img
                :src="require('assets/images/instagram.png')"
                alt="instagram"
                class="social-icon"
              />
            </a>
          </div>
        </div>
      </div>

      <div v-if="videos" class="youtube-container row">
        <div v-for="video in videos" :key="video" class="col-12 col-md-6">
          <div class="iframe-container">
            <iframe
              :src="`https://www.youtube.com/embed/${video}`"
              class="ytplayer"
              type="text/html"
              frameborder="0"
            />
          </div>
        </div>
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
      title: `| ${this.getCurrentBand.name}`
    }
  },
  components: {
    Slideshow
  },
  data() {
    return {
      bands: {}
    }
  },
  computed: {
    ...mapGetters('bands', ['getCurrentBand']),
    ...mapGetters(['language']),

    description() {
      return this.$store.getters.language === 'de'
        ? this.getCurrentBand.descriptionDe
        : this.getCurrentBand.descriptionFr
    },
    videos() {
      if (this.getCurrentBand.youtubeUrls) {
        return this.getCurrentBand.youtubeUrls.replace(/\s/g, '').split(',')
      }
      return ''
    }
  },

  mounted() {
    this.loadCurrentBand(this.$route.params.id)
  },

  methods: {
    ...mapActions('bands', ['loadCurrentBand'])
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

.band-image {
  max-height: 100%;
  max-width: 100%;
}

.ytplayer {
  width: 100%;
  height: 300px;
}

.youtube-container {
  margin-top: 50px;
}

.social-media {
  float: left;
  margin-right: 20px;
}

.social-icon {
  width: 32px;
}

.social-media-wrapper {
  width: 100%;
}

.social-media-container {
  margin: 20px 20px 20px 0;
}

.spotify {
  float: right;
  width: 100%;
  max-width: 340px;
  height: 400px;
}

.band-website {
  margin: 20px 0 20px 0;
}

.myContainer {
  padding-top: 40;
}
.container {
  margin-top: 30px;
}

@media (max-width: 768px) {
  .spotify {
    float: left;
  }
  .text-content {
    margin-bottom: 20px;
  }
  .slideshow {
    height: 320px;
  }
}
</style>
