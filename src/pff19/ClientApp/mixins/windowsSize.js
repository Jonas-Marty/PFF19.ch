import { MOBILE, TABLET } from '../constants/devices'

const windowSize = {
  data() {
    return {
      window: {
        width: 0,
        height: 0
      }
    }
  },
  created() {
    window.addEventListener('resize', this.handleResize)
    this.handleResize()
  },
  destroyed() {
    window.removeEventListener('resize', this.handleResize)
  },
  methods: {
    handleResize() {
      this.window.width = window.innerWidth
      this.window.height = window.innerHeight
    }
  },
  computed: {
    isMobile() {
      return this.window.width <= MOBILE
    },
    isTablet() {
      return this.window.width > MOBILE && this.width <= TABLET
    }
  }
}

export default windowSize
