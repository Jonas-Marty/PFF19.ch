<template>
    <div class="slideshow">
        <div class="container">
            <div class="row">

                <div class="image-container col-md col-sm-12">
                    <img class="logo col" src="../../../assets/images/logo_yellow_with_text.png">
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
        margin: auto;
        height: auto;
    }

    .row {
        padding-top: 170px;
    }

    @media (max-width: 768px) { 
        .row {
        padding-top: 70px;
        }

        .logo {
            margin: auto;
            margin-bottom: 30px;
            margin-top: 20px;
        }
     }

</style>
