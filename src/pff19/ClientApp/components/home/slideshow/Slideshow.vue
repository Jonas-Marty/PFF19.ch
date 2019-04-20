<template>
    <div class="slideshow">
        <div class="container">
            <div class="content-block">
                <picture>
                    <source media="(max-width: 768px)" :srcset="HomeImgMQ123" alt="slidshow-img" />
                    <img :src="HomeImgMQ45" alt="slideshow-img" />
                </picture>
            </div>

            <div class="row">
                <div class="image-container col-md col-sm-12">
                    <img
                        class="logo"
                        srcset="
                            ../../../assets/images/logo_yellow_with_text.png        400w,
                            ../../../assets/images/logo_yellow_with_text_retina.png 800w
                        "
                        sizes="400px"
                        src="../../../assets/images/logo_yellow_with_text.png"
                        alt="pff-logo"
                    />

                    <router-link :to="{ name: 'ticketing' }">
                        <div class="btn btn-danger ticket-btn btn-lg font-weight-bold">
                            {{ $t(`lang.components.home.slideshow.ticket_btn`) | uppercase }}
                        </div>
                    </router-link>
                </div>

                <app-countdown class="col-md col-sm-12"></app-countdown>
            </div>
        </div>
        <img class="slideshow-overlay" src="../../../assets/images/slideshow-overlay.svg" />
    </div>
</template>
<script>
import Countdown from './Countdown'
import HomeImgMQ45 from '../../../assets/images/home_img_mq5.jpg'
import HomeImgMQ123 from '../../../assets/images/home_img_mq12.jpg'

import i18n from '../../../locales'

export default {
    data() {
        return {
            HomeImgMQ45,
            HomeImgMQ123
        }
    },
    components: {
        'app-countdown': Countdown
    }
}
</script>

<style lang="scss" scoped>
.slideshow {
    height: 800px;
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

.logo {
    display: block;
    max-width: 400px;
}

.row {
    padding-top: 170px;
}

.ticket-btn {
    margin: 20px auto;
}

@media (max-width: 767px) {
    .row {
        padding-top: 70px;
    }

    .logo {
        margin-left: auto;
        margin-right: auto;
        max-width: 80%;
        margin-top: 20px;
        margin-bottom: 20px;
    }

    .ticket-btn {
        width: 80%;
        margin: 0px auto 20px auto;
        display: block;
    }
}
</style>
