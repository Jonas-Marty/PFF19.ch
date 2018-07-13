<template>
    <div class="news col-md">
        <div class="card">
            <div class="card-img-top" :style="'background-image: url(' + imagePath +')'" alt="Card image"></div>
            <div class="card-body">
                <div class="card-title">
                    {{ news.title }}
                </div>
                <div class="card-text">
                    {{ news.content | shorten(150)}}
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
            return require("assets/news/" + this.news.image);
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
