<template>
  <div class="container ytvideo">
    <div class="row">
      <div class="col-12 col-md-12 col-lg-6">
        <div class="iframe-container text-center">
          <iframe
            class="ytplayer"
            type="text/html"
            src="https://www.youtube.com/embed/kniePtth694"
            frameborder="0"
            allowfullscreen
          />
        </div>
      </div>
        <div class="col-12 col-md-12 col-lg-6">
        <div class="iframe-container text-center">
          <iframe
            class="ytplayer"
            type="text/html"
            src="https://www.youtube-nocookie.com/embed/bolKNT1PuSQ"
            frameborder="0"
            allowfullscreen
          />
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.ytvideo {
  margin: 80px auto;
}
.ytplayer {
  max-width: 780px;
  height: 400px;
  width: 100%;
}

@media (max-width: 767px) {
  .ytplayer {
    height: 300px;
  }
  .ytvideo {
    margin-bottom: 0;
  }
}
</style>
