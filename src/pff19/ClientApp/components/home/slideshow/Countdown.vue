<template>
  <div class="app-countdown">
    <div class="row">
      <div class="days col-md-12 col-12">
        <div class="row justify-content-md-end justify-content-center">
          <div v-for="(day, index) in time.days" :key="index" class="day">
            {{ day }}
          </div>
        </div>
        <div class="countdown-text">
          <strong>{{ $t('lang.components.home.slideshow.countdown.days') | uppercase }}</strong>
        </div>
      </div>
      <div class="hours col-md-12 col-12">
        <div class="row justify-content-md-end justify-content-center">
          <div v-for="(hour, index) in time.hours" :key="index" class="hour">
            {{ hour }}
          </div>
        </div>
        <div class="countdown-text justify-content-md-end justify-content-center">
          <strong>{{ $t('lang.components.home.slideshow.countdown.hours') | uppercase }}</strong>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  computed: {
    time() {
      const distance = new Date('Aug 30, 2019 17:00:00').getTime() - new Date().getTime()
      const days = Math.floor(distance / (1000 * 60 * 60 * 24))
        .toString()
        .split('')
      const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60))
        .toString()
        .split('')
      return { days, hours }
    }
  }
}
</script>

<style lang="scss" scoped>
.day,
.hour {
  background: #f4d82b;
  font-size: 2.5rem;
  font-weight: bold;
  margin-right: 5px;
  text-align: center;
  width: 50px;
}

.days,
.hours {
  margin-bottom: 20px;
}

.countdown-text {
  font-size: 2.5rem;
  color: #ffffff;
  text-align: right;
}

@media (max-width: 767px) {
  .countdown-text {
    text-align: center;
  }
}
</style>
