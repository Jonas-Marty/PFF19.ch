<template>
  <div class="container ytvideo">
    <div class="row">
      <div class="col-12 offset-md-2 col-md-8 offset-lg-2 col-lg-8">
        <div class="iframe-container text-center">
          <iframe
            class="ytplayer"
            type="text/html"
            src="https://www.youtube-nocookie.com/embed/jJDrwRzCLac"
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
  margin: 50px auto;
}
.ytplayer {
  max-width: 750px;
  height: 400px;
  width: 80%;
}

@media (max-width: 767px) {
  .ytplayer {
    height: 300px;
  }
}
</style>
