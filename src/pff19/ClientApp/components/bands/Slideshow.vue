<template>
    <div class="slideshow">
        <div class="container">
            <div class="content-block">
                <picture class="background-img">
                    <source media="(max-width: 768px)" :srcset="`assets/bands/mobile/${imageMobile}`" alt="slidshow-img" class="img-fluid background-img">
                    <img :src="`assets/bands/images/${getFirstImage}`" alt="slideshow-img" class="img-fluid background-img">
                </picture>
            </div>
        <img class="slideshow-overlay" src="../../assets/images/slideshow-overlay.svg"/>
        </div>
    </div>
</template>
<script>
export default {
    props: ['images', 'imageMobile'],
    data() {
        return {
        }
    },
    
    computed: {
         getFirstImage () {
            if(this.images){
                return this.images.split(';')[0]
            }
        },
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

   .ticket-btn{
        margin:20px auto;
    }

    .background-img {
        min-width: 100%;
    }

    @media (max-width: 1024px) {
        .slideshow {
            height: 480px;
        }
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

        .ticket-btn{
            width: 80%;
            margin: 0px auto 20px auto;
            display: block;

        }

     }

</style>
