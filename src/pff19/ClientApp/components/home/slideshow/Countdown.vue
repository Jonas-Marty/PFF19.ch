<template>
<div class="app-countdown">
    <div class="row">
        <div class="days col-md-12 col-12">
            <div class="row justify-content-md-end justify-content-center">
                <div class="day" v-for="(day, index) in time.days" :key="index">
                    {{ day }}
                </div>
            </div>
            <div class="countdown-text">
                <strong>{{ $t('lang.components.home.slideshow.countdown.days') | uppercase}}</strong>
            </div>
        </div>
        <div class="hours col-md-12 col-12">
            <div class="row justify-content-md-end justify-content-center">
                <div class="hour" v-for="(hour, index) in time.hours" :key="index">
                    {{ hour }}
                </div>
            </div>
            <div class="countdown-text justify-content-md-end justify-content-center">
                <strong>{{ $t('lang.components.home.slideshow.countdown.hours') | uppercase}}</strong>
            </div>
        </div>
    </div>
</div>
    
</template>

<script>
export default {

    computed: {
        time () {
            const distance = (new Date("Aug 30, 2019 17:00:00").getTime() - new Date().getTime()); 
            const days = Math.floor(distance / (1000 * 60 * 60 * 24)).toString().split("");
            const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)).toString().split("");
            return {days, hours};
        }
    }
    
}
</script>

<style lang="scss" scoped>
    .day, .hour {
        background: #F4D82B;
        padding: 3px 15px 3px 15px;
        font-size: 2.5rem;
        font-weight: bold;
        margin-right: 5px;
        text-align: center;
    }

    .days, .hours {
        margin-bottom: 20px;
    }

    .countdown-text {
        font-size: 2.5rem;
        color: #ffffff;
        text-align: right;
    }

    @media (max-width: 768px) { 
        .countdown-text {
            text-align: center;
        }
    }


</style>
