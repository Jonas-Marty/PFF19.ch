<template>
    <div class="news col-md">
        <div class="card">
            <img class="card-img-top" :src="imagePath" alt="Card image">
            <div class="card-body">
                <div class="card-title">
                    {{ news.title }}
                </div>
                <div class="card-text">
                    {{ news.short }}
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
            return require("../../../assets/images/" + this.news.image + ".jpg");
        }
    }

}
</script>

<style lang="scss" scoped>
    .news {
        margin-bottom: 20px;
    }
    .card-title {
        font-family: "Glacial Indifference Bold"
    }
</style>
