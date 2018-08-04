<template>
    <div class="news col-md-4">
        <div class="card">
            <div class="card-img-top" :style="'background-image: url(' + imagePath +')'" alt="Card image"></div>
            <div class="card-body">
                <div class="card-title">
                    <router-link
                    :to="{name: 'news', params: {id: news.id}}"
                    >
                    {{ newsTitle }}
                    </router-link>
                </div>
                <div class="card-text">
                    {{ newsPreview | shorten(150)}}
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: ['news'],

    computed: {
        imagePath () {
            return require("../../../assets/news/thumbnails/" + this.news.image);
        },
        newsPreview () {
            return   this.$store.getters.language === 'de' ? this.news.previewDe : this.news.previewFr;
        },
        newsTitle () {
            return   this.$store.getters.language === 'de' ? this.news.titleDe : this.news.titleFr;
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
        font-family: "Glacial Indifference Bold"
    }
    .card-img-top {
        height: 220px;
        background-size: cover;
    }
</style>
