<template>
    <div class="slideshow">
        <div class="container">
            <div class="content-block">
                <picture>
                    <source media="(max-width: 768px)" :srcset="HelperImgMQ12" alt="slidshow-img" />
                    <img :src="HelperImg" alt="slideshow-img" />
                </picture>
            </div>
        </div>
        <div class="slideshow-overlay">
            <img src="../../assets/images/slideshow-overlay.svg" />
        </div>
    </div>
</template>
<script>
import HelperImg from '../../assets/images/helper_image.jpg'
import HelperImgMQ12 from '../../assets/images/helper_image_mq12.jpg'

export default {
    data() {
        return {
            HelperImg,
            HelperImgMQ12
        }
    }
}
</script>

<style lang="scss" scoped>
.slideshow {
    height: 630px;
    width: 100%;
    position: relative;
    overflow: hidden;
}

.slideshow-overlay {
    position: absolute;
    bottom: -5px;
    right: -3px;
    width: 100%;
}

.content-block {
    position: absolute;
    display: flex;
    justify-content: center;
    align-items: center;
    left: 0;
    right: 0;
    top: 0;
    bottom: 0;
}

.row {
    padding-top: 170px;
}

@media (max-width: 768px) {
    .slideshow {
        height: 400px;
    }
}
</style>
