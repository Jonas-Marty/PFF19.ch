<template>
    <div class="social-media">
        <img class="top-overlay" :src="require('assets/images/social_media_top_overlay.svg')"/>
        <div class="container">
            <div class="row flex-md-row-reverse">
                <div class="col-md-4 col-12">
                    <h2>Social Media</h2>
                </div>
                <div class="col-md-8 col-12">
                    sadf
                </div>
            </div>
        </div>
        <img class="bottom-overlay" :src="require('assets/images/social_media_bottom_overlay.svg')"/>
    </div>
</template>

<script>
export default {

}
</script>

<style lang="scss" scoped>
    .social-media {
        width: 100%;
        height: 800px;
        background: #C20812;
        margin-top: 50px;
        padding: 150px 0 100px 0;
        color: white;
        position: relative;
        overflow: hidden;
    }

    .top-overlay {
        position: absolute;
        top: -1px;
        right: -10px;
    }

    .bottom-overlay {
        position: absolute;
        bottom: -1px;
        right: -10px;
    }
</style>

