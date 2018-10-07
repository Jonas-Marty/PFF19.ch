<template>
    <div class="news col-md-8 offset-md-2 col-lg-4 offset-lg-0">
        <div class="card">
            <div class="card-img-top" :style="imagePath" alt="Card image"></div>
            <div class="card-body">
                <div class="card-title">
                    <router-link
                    :to="{name: 'news', params: {id: news.id}}"
                    >
                    {{ newsTitle }}
                   
                    </router-link>
                </div>
                <div class="card-text">
                    {{ newsPreview | shorten(160) }}
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
            return "background-image: url(/assets/news/thumbnail/" + this.news.image + ")";

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
