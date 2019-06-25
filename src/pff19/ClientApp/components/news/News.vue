<template>
  <div class="container">
    <div class="row justify-content-center">
      <div class="col-lg-8">
        <div class="row back">
          <div class="col">
            <router-link class="btn btn-outline-primary" to="/news">Alle News</router-link>
          </div>
        </div>

        <h1>{{ newsTitle }}</h1>
        <img :src="`/assets/news/images/${getFirstImage}`" :alt="newsTitle" class="img" />
        <div class="date">{{ getCurrentNews.date | formateDate(language) }}</div>
        <br />
        <br />

        <div v-html="newsContent" class="text-content"></div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  metaInfo() {
    return {
      title: `| ${this.newsTitle}`
    }
  },
  data() {
    return {
      news: {}
    }
  },

  computed: {
    ...mapGetters('news', ['getCurrentNews']),
    ...mapGetters(['language']),
    newsTitle() {
      return this.$store.getters.language === 'de'
        ? this.getCurrentNews.titleDe
        : this.getCurrentNews.titleFr
    },
    newsContent() {
      return this.$store.getters.language === 'de'
        ? this.getCurrentNews.contentDe
        : this.getCurrentNews.contentFr
    },
    // eslint-disable-next-line vue/return-in-computed-property
    getFirstImage() {
      if (this.getCurrentNews.images) {
        return this.getCurrentNews.images.split(';')[0]
      }
    }
  },

  mounted() {
    this.loadCurrentNews(this.$route.params.id)
  },

  methods: {
    ...mapActions('news', ['loadCurrentNews'])
  }
}
</script>

<style lang="scss" scoped>
h1 {
  margin-bottom: 20px;
}
.container {
  padding-top: 100px;
}

.img {
  max-height: 500px;
  max-width: 100%;
  background-size: cover;
  margin-bottom: 20px;
}

.date {
  margin-bottom: 30px;
}

.back {
  margin-bottom: 30px;
}
</style>
