<template>
  <div class="container-fluid">
    <app-polygon color="green" position="left"></app-polygon>
    <div class="container faq">
      <div class="offset-lg-1 col-lg-10">
        <h1>FAQ's</h1>
        <div v-for="faq in orderedFaqs" :key="faq.id">
          <question :question="faq"></question>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
import Question from './Question'
export default {
  metaInfo() {
    return {
      title: `| ${this.$i18n.t('lang.navigation.faq')}`
    }
  },
  components: {
    Question
  },
  computed: {
    ...mapGetters(['language']),
    ...mapGetters('faqs', ['all']),
    orderedFaqs() {
      // eslint-disable-next-line vue/no-side-effects-in-computed-properties
      return this.all.sort((a, b) => a.order - b.order)
    }
  },
  created() {
    this.load()
  },

  methods: {
    ...mapActions('faqs', ['load'])
  }
}
</script>

<style lang="scss" scoped>
.faq {
  position: relavtive;
}
.container {
  padding-top: 100px;
  min-height: 1000px;
}
</style>
