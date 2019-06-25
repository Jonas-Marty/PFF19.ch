<template>
  <div class="myContainer">
    <slideshow
      :images="`assets/bands/mobile/${this.getCurrentBand.imageLarge}`"
      :imageMobile="`assets/bands/mobile/${this.getCurrentBand.imageMobile}`"
    />
    <div class="container">
      <div class="row back">
        <div class="col">
          <router-link class="btn btn-outline-primary" :to="{ name: 'bandsOverview' }"
            >Alle Bands</router-link
          >
        </div>
      </div>
      <h1 class="title">{{ this.getCurrentBand.name }}</h1>
      <h6 class="title-playtime">
        {{ this.getCurrentBand.playTimeForSorting | formateDateTime(language) }}
      </h6>

      <div class="row" v-if="this.getCurrentBand.spotifyPlaylist">
        <div class="col-12 col-md-6 text-content" v-html="description"></div>
        <div class="col-12 col-md-6">
          <iframe
            class="spotify"
            :src="this.getCurrentBand.spotifyPlaylist"
            frameborder="0"
            allowtransparency="true"
            allow="encrypted-media"
          ></iframe>
        </div>
      </div>

      <div class="row" v-else>
        <div class="col-12 text-content" v-html="description"></div>
      </div>

      <div class="row" v-if="this.getCurrentBand.webSiteUrl">
        <div class="col-12 band-website">
          <a :href="this.getCurrentBand.webSiteUrl">Band Website</a>
        </div>
      </div>

      <div class="row" v-if="this.getCurrentBand.facebook || this.getCurrentBand.instagram">
        <div class="col-12 social-media-container">
          <div class="social-media" v-if="this.getCurrentBand.facebook">
            <a :href="this.getCurrentBand.facebook">
              <img
                :src="require('assets/images/facebook.png')"
                alt="facebook"
                class="social-icon"
              />
            </a>
          </div>
          <div class="social-media" v-if="this.getCurrentBand.instagram">
            <a :href="this.getCurrentBand.instagram">
              <img
                :src="require('assets/images/instagram.png')"
                alt="instagram"
                class="social-icon"
              />
            </a>
          </div>
        </div>
      </div>

      <div class="youtube-container row" v-if="videos">
        <div v-for="video in videos" :key="video" class="col-12 col-md-6">
          <div class="iframe-container">
            <iframe
              class="ytplayer"
              type="text/html"
              :src="`https://www.youtube.com/embed/${video}`"
              frameborder="0"
            />
          </div>
        </div>
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
      title: `| ${this.getCurrentBand.name}`
    }
  },
  data() {
    return {
      bands: {}
    }
  },

  components: {
    Slideshow
  },

  methods: {
    ...mapActions('bands', ['loadCurrentBand'])
  },

  mounted() {
    this.loadCurrentBand(this.$route.params.id)
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
