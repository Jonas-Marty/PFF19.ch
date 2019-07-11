<template>
  <div class="card question">
    <div @click="showQuestion = !showQuestion" class="card-header">
      <h3 class="dropdown-toggle text-wrap">{{ questionTitle }}</h3>
    </div>
    <div v-if="showQuestion" class="card-body">
      <div v-html="questionAnswer" class="text-content"></div>
    </div>
  </div>
</template>
<script>
export default {
  // eslint-disable-next-line vue/require-prop-types
  props: ['question'],
  data() {
    return {
      showQuestion: false
    }
  },

  computed: {
    questionTitle() {
      return this.$store.getters.language === 'de'
        ? this.question.questionDe
        : this.question.questionFr
    },

    questionAnswer() {
      return this.$store.getters.language === 'de' ? this.question.answerDe : this.question.answerFr
    }
  }
}
</script>

<style lang="scss">
.text-content img {
  max-width: 100%;
}
</style>

<style lang="scss" scoped>
.question {
  margin-top: 30px;
  word-break: break-word;
}

.card-header {
  cursor: pointer;
}
</style>
