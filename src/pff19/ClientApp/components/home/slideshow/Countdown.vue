<template>
<div class="app-countdown">
    <div class="row col-12">
        <div class="days col-md-12 col-12">
            <div class="row justify-content-md-end justify-content-center">
                <div class="day" v-for="day in time.days" :key="day">
                    {{ day }}
                </div>
            </div>
            <div class="countdown-text">
                <strong>TAGE</strong>
            </div>
        </div>
        <div class="hours col-md-12 col-12">
            <div class="row justify-content-md-end justify-content-center">
                <div class="hour" v-for="hour in time.hours" :key="hour">
                    {{ hour }}
                </div>
            </div>
            <div class="countdown-text justify-content-md-end ">
                <strong>STUNDEN</strong>
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
        text-align: center;
        font-size: 2.5rem;
        font-weight: bold;
        margin-right: 5px;
        width: 50px;
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
