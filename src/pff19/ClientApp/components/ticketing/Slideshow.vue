<template>
    <div class="slideshow">
        <div class="container">
            <div class="row">
                <div class="image-container col-md col-sm-12">
                </div>
                                
            </div>
        </div>
        <img class="slideshow-overlay" src="../../assets/images/slideshow-overlay.svg"/>
    </div>
</template>
<script>
export default {
    
}
</script> 

<style lang="scss" scoped>
    .slideshow { 
        background: url('../../assets/images/ticketing_img.jpg');
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
