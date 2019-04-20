<template>
    <div class="news col-md-4">
        <div class="card">
            <img class="card-img-top" :src="`/assets/news/thumbnail/${getFirstImage}`" />
            <div class="card-body">
                <div class="card-title">
                    <router-link :to="{ name: 'news', params: { id: news.id } }">
                        {{ newsTitle }}
                    </router-link>
                </div>
                <div class="card-text">
                    {{ newsPreview | shorten(150) }}
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: ['news'],

    computed: {
        newsPreview() {
            return this.$store.getters.language === 'de' ? this.news.previewDe : this.news.previewFr
        },
        newsTitle() {
            return this.$store.getters.language === 'de' ? this.news.titleDe : this.news.titleFr
        },
        getFirstImage() {
            return this.news.images.split(';')[0]
        }
    }
}
</script>

<style lang="scss" scoped>
.news {
    margin-bottom: 20px;
}

.card {
    padding: 2px;
}

.card-title {
    font-family: 'Glacial Indifference Bold';
}
.card-img-top {
    max-width: 100%;
    margin: auto;
    background-size: cover;
}
</style>
