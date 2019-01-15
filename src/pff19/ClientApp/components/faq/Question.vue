<template>
    <div class="question">
        <h3>{{ questionTitle }}</h3>
        <div class="text-content" v-html="questionAnswer"></div>

    </div>
</template>
<script>

export default {
    props: ['question'],

    computed: {
        questionTitle () {
            return this.$store.getters.language === 'de' ? this.question.questionDe : this.question.questionFr;
        },

        questionAnswer () {
            return this.$store.getters.language === 'de' ? this.question.answerDe : this.question.answerFr;
        }
    }

}
</script>

<style lang="scss" scoped>
.question {
    margin-top: 30px;
}
</style>
