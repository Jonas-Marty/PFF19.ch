<template>
  <div class="sponsor col-10 col-md-4">
    <a :href="sponsor.link" target="_blank">
      <div class="sponsor-img-wrapper">
        <img :src="imagePath" :alt="sponsor.name" class="sponsor-img mx-auto" />
      </div>
    </a>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  // eslint-disable-next-line vue/require-prop-types
  props: ['sponsor'],

  computed: {
    ...mapGetters('sponsors', ['mainSponsors']),

    imagePath() {
      return `/assets/sponsors/images/${this.sponsor.logo}`
    }
  },

  created() {
    this.load()
  },

  methods: {
    ...mapActions('sponsors', ['load'])
  }
}
</script>

<style lang="scss" scoped>
.sponsor-img {
  display: block;
  margin: auto;
  max-height: 200px;
  max-width: 100%;
}

.sponsor {
  padding: 5px;
  margin: auto;
}

.sponsor-img-wrapper {
  padding: 15px;
  margin-top: 10px;
}
</style>
