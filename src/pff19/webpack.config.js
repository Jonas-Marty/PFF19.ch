const path = require('path')
const webpack = require('webpack')
const VueLoaderPlugin = require('vue-loader/lib/plugin')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const PrerenderSPAPlugin = require('prerender-spa-plugin')
var HtmlWebpackPlugin = require('html-webpack-plugin')
const bundleOutputDir = './wwwroot/dist'

module.exports = () => {
  console.log('Building for \x1b[33m%s\x1b[0m', process.env.NODE_ENV)
  const isDevBuild = !(process.env.NODE_ENV && process.env.NODE_ENV === 'production')
  return [{
    mode: isDevBuild ? 'development' : 'production',
    devtool: isDevBuild ? 'inline-source-map' : false,
    stats: { modules: false },
    entry: { 'main': './ClientApp/boot-app.js' },
    resolve: {
      extensions: ['.js', '.vue'],
      alias: isDevBuild ? {
        'vue$': 'vue/dist/vue',
        'components': path.resolve(__dirname, './ClientApp/components'),
        'views': path.resolve(__dirname, './ClientApp/views'),
        'utils': path.resolve(__dirname, './ClientApp/utils'),
        'api': path.resolve(__dirname, './ClientApp/store/api'),
        'assets': path.resolve(__dirname, './ClientApp/assets')
      } : {
        'components': path.resolve(__dirname, './ClientApp/components'),
        'views': path.resolve(__dirname, './ClientApp/views'),
        'utils': path.resolve(__dirname, './ClientApp/utils'),
        'api': path.resolve(__dirname, './ClientApp/store/api'),
        'assets': path.resolve(__dirname, './ClientApp/assets')
      }
    },
    output: {
      path: path.join(__dirname, bundleOutputDir),
      filename: '[name].js',
      publicPath: '/dist/'
    },
    module: {
      rules: [
        { test: /\.vue$/, include: /ClientApp/, use: 'vue-loader' },
        { test: /\.js$/, include: /ClientApp/, use: 'babel-loader' },
        { test: /\.css$/, use: [isDevBuild ? 'style-loader' : MiniCssExtractPlugin.loader, 'css-loader'] },
        { test: /\.scss$/,
          use: [isDevBuild ? 'style-loader' : MiniCssExtractPlugin.loader, 'css-loader', 'sass-loader']
        },
        { test: /\.(png|jpg|jpeg|gif|svg|png)$/, use: 'url-loader?limit=25000' },
        {
          test: /\.(woff(2)?|ttf|eot)(\?v=\d+\.\d+\.\d+)?$/,
          use: [{
            loader: 'file-loader',
            options: {
              name: '[name].[ext]',
              outputPath: 'fonts/'
            }
          }]
        }
      ]
    },
    plugins: [
      new VueLoaderPlugin(),
      new MiniCssExtractPlugin({
        filename: '[name].css'
      }),
      new HtmlWebpackPlugin({
        title: 'pff19',
        filename: path.resolve(__dirname, bundleOutputDir, 'index.html'),
        template: path.resolve(__dirname, bundleOutputDir, 'index.html')
      }),
      new webpack.DllReferencePlugin({
        context: __dirname,
        manifest: require('./wwwroot/dist/vendor-manifest.json')
      })
    ]
  }]
}

if (process.env.NODE_ENV === 'production') {
  module.exports.devtool = '#source-map'
  module.exports.plugins = (module.exports.plugins || []).concat([
    new PrerenderSPAPlugin({
      staticDir: path.join(__dirname, bundleOutputDir),
      routes: [ '/', '/organisation', '/helfer' ],

      renderer: new PrerenderSPAPlugin.PuppeteerRenderer({
        headless: false,
        renderAfterDocumentEvent: 'render-event'
      })
    })
  ])
}
