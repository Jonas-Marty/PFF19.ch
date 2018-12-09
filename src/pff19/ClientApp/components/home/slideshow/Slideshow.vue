<template>
    <div class="slideshow">
        <div class="container">
            <div class="row">
                <div class="image-container col-md col-sm-12">
                    <img class="logo" 
                    srcset="../../../assets/images/logo_yellow_with_text.png 400w,
                    ../../../assets/images/logo_yellow_with_text_retina.png 800w"
                    sizes="400px"
                    src="../../../assets/images/logo_yellow_with_text.png" alt="pff-logo">
                </div>
                    
                <app-countdown class="col-md col-sm-12"></app-countdown>
                
            </div>
        </div>
        <img class="slideshow-overlay" src="../../../assets/images/slideshow-overlay.svg"/>
    </div>
</template>
<script>
import Countdown from './Countdown';

export default {

    components: {
        'app-countdown': Countdown 
    }
    
}
</script> 

<style lang="scss" scoped>
    .slideshow { 
        background: url('../../../assets/images/slideshow.jpg');
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
    }

    .logo {
        display: block;
        max-width: 400px;
    }

    .row {
        padding-top: 170px;
    }

    @media (max-width: 768px) { 
        .row {
        padding-top: 70px;
        }

        .logo {
            margin-left: auto;
            margin-right: auto;
            max-width: 80%;
            margin-bottom: 50px;
            margin-top: 20px;
        }
     }

</style>
