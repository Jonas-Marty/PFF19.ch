<template>
    <div class="card question">
        <div @click="showQuestion = !showQuestion" class="card-header">
            <h3 class=" dropdown-toggle">{{ questionTitle }}</h3>
        </div>
        <div v-if="showQuestion" class="card-body">
            <div class="text-content" v-html="questionAnswer"></div>
        </div>
    </div>
</template>
<script>
export default {
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
            return this.$store.getters.language === 'de'
                ? this.question.answerDe
                : this.question.answerFr
        }
    }
}
</script>

<style lang="scss" scoped>
.question {
    margin-top: 30px;
    word-break: break-all;
}

.card-header {
    cursor: pointer;
}
</style>
