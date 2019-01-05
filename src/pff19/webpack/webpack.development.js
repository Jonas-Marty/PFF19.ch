module.exports = () => ({
  mode: 'development',
  devtool: 'inline-source-map',
  stats: { modules: false },
  entry: {'main': './ClientApp/boot-app.js'},
  resolve: {
    extensions: ['.js', '.vue'],
    alias: {
      'vue$': 'vue/dist/vue'
    }
  },
  module: {
    rules: [
      { test: /\.css$/, use: ['style-loader', 'css-loader'] },
      { test: /\.scss$/,
        use: ['style-loader', 'css-loader', 'sass-loader']
      }
    ]
  }
}
)
