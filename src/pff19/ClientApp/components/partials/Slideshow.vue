<template>
    <div class="slideshow" :style="`background-image: url(${getImage})`">
        <div class="container">
            <div class="row">
                <div class="image-container col-md col-sm-12"></div>
            </div>
        </div>
        <img class="slideshow-overlay" src="../../assets/images/slideshow-overlay.svg" />
    </div>
</template>
<script>
import windowsSize from 'mixins/windowsSize'
export default {
    mixins: [windowsSize],
    props: ['images', 'imageMobile'],

    computed: {
        getImage() {
            if (this.isMobile && this.imageMobile) {
                return this.imageMobile
            } else {
                if (this.images) {
                    return this.images.split(';')[0]
                }
            }
        }
    }
}
</script>

<style lang="scss" scoped>
.slideshow {
    height: 630px;
    width: 100%;
    background-repeat: no-repeat;
    background-size: cover;
    background-position: center;
    position: relative;
    overflow: hidden;
}

.slideshow-overlay {
    position: absolute;
    bottom: -1px;
    right: -3px;
    width: 100%;
}

@media (max-width: 1024px) {
    .slideshow {
        height: 480px;
    }
}
</style>
