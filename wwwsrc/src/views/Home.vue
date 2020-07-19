<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <div class="col-6 text-center">
        <!-- <img class="home-img" src="../assets/keepr.png" alt /> -->
      </div>
      <!-- Carousel -->
      <div class="col-11 mt-3 carousel-fade">
        <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
          <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
          </ol>
          <div class="carousel-inner">
            <div class="carousel-item active">
              <img src="../assets/cat-picture.jpg" class="d-block carousel-img" alt />
            </div>
            <div class="carousel-item">
              <img src="../assets/dragon-bird.jpg" class="d-block carousel-img" alt />
            </div>
            <div class="carousel-item">
              <img src="../assets/stairs-picture.jpg" class="d-block carousel-img" alt />
            </div>
          </div>
          <a
            class="carousel-control-prev"
            href="#carouselExampleIndicators"
            role="button"
            data-slide="prev"
          >
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
          </a>
          <a
            class="carousel-control-next"
            href="#carouselExampleIndicators"
            role="button"
            data-slide="next"
          >
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
          </a>
        </div>
      </div>
    </div>
    <!-- Keeps -->
    <div class="row mt-3 mx-2">
      <div class="card-columns">
        <keep v-for="keep in keeps" :key="keep.Id" :keep="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/KeepComponent";
export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.KeepsStore.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    keep
  }
};
</script>

<style scoped>
.carousel-img {
  width: 1400px;
  height: 700px;
}

.home-img {
  height: 150px;
}
</style>
