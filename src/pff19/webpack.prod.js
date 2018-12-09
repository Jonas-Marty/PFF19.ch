const path = require('path')
const VueLoaderPlugin = require('vue-loader/lib/plugin')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
var HtmlWebpackPlugin = require('html-webpack-plugin')
const bundleOutputDir = './wwwroot/dist'

module.exports = () => {
  console.log('Building for \x1b[33m%s\x1b[0m', process.env.NODE_ENV)
  return [{
    mode: 'production',
    devtool: false,
    stats: { modules: false },
    entry: { 'main': './ClientApp/boot-app.js' },
    optimization: {
      splitChunks: {
        chunks: 'all'
      }
    },
    resolve: {
      extensions: ['.js', '.vue'],
      alias: {
        'components': path.resolve(__dirname, './ClientApp/components'),
        'views': path.resolve(__dirname, './ClientApp/views'),
        'utils': path.resolve(__dirname, './ClientApp/utils'),
        'api': path.resolve(__dirname, './ClientApp/store/api'),
        'assets': path.resolve(__dirname, './ClientApp/assets')
      }
    },
    output: {
      path: path.join(__dirname, bundleOutputDir),
      filename: '[name].[chunkhash].bundle.js'
    },
    module: {
      rules: [
        { test: /\.vue$/, include: /ClientApp/, use: 'vue-loader' },
        { test: /\.js$/, include: /ClientApp/, use: 'babel-loader' },
        { test: /\.css$/, use: [MiniCssExtractPlugin.loader, 'css-loader'] },
        { test: /\.scss$/,
          use: [MiniCssExtractPlugin.loader, 'css-loader', 'sass-loader']
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
        title: 'PFF FFS 19 – Mosaik',
        template: path.resolve(__dirname, 'ClientApp/index.html'),
        filename: path.resolve(__dirname, bundleOutputDir, 'index.html')
      })
    ]
  }]
}
