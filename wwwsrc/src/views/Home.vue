<template>
  <div class="home container-fluid">
    <div class="row justify-content-center">
      <div class="col-6 text-center mt-2">
        <h3>Welcome to Keepr</h3>
      </div>
      <!-- Carousel -->
      <div class="col-11 mt-3 carousel-fade" v-if="keeps.length > 0">
        <div
          id="carouselExampleIndicators"
          class="carousel slide"
          data-ride="carousel"
        >
          <ol class="carousel-indicators">
            <li
              data-target="#carouselExampleIndicators"
              data-slide-to="0"
              class="active"
            ></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
          </ol>
          <div class="carousel-inner">
            <div class="carousel-item active">
              <img
                @click="
                  $router.push({
                    name: 'keep-details',
                    params: { id: keeps[randomNumbers.num1].id },
                  })
                "
                :src="keeps[randomNumbers.num1].img"
                class="d-block carousel-img"
                alt
              />
            </div>
            <div class="carousel-item">
              <img
                @click="
                  $router.push({
                    name: 'keep-details',
                    params: { id: keeps[randomNumbers.num2].id },
                  })
                "
                :src="keeps[randomNumbers.num2].img"
                class="d-block carousel-img"
                alt
              />
            </div>
            <div class="carousel-item">
              <img
                @click="
                  $router.push({
                    name: 'keep-details',
                    params: { id: keeps[randomNumbers.num3].id },
                  })
                "
                :src="keeps[randomNumbers.num3].img"
                class="d-block carousel-img"
                alt
              />
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
    <div class="row justify-content-center mt-3" v-if="keeps.length < 1">
      <div class="col-9 text-center">
        <h1>
          There doesnt seem to be any Keeps posted yet. Get started by sharing
          some things you enjoy!
        </h1>
      </div>
    </div>
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
    },
    randomNumbers() {
      let nums = {
        num1: Math.floor(Math.random() * (this.keeps.length - 1)),
        num2: Math.floor(Math.random() * (this.keeps.length - 1)),
        num3: Math.floor(Math.random() * (this.keeps.length - 1)),
      };
      return nums;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
  components: {
    keep,
  },
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
