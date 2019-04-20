const path = require('path');
const VueLoaderPlugin = require('vue-loader/lib/plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
var HtmlWebpackPlugin = require('html-webpack-plugin');
const bundleOutputDir = './wwwroot/dist';

module.exports = () => {
  console.log('Building for \x1b[33m%s\x1b[0m', process.env.NODE_ENV);
  return [
    {
      mode: 'development',
      devtool: 'inline-source-map',
      stats: { modules: false },
      entry: { main: './ClientApp/boot-app.js' },
      optimization: {
        splitChunks: {
          chunks: 'all'
        }
      },
      resolve: {
        extensions: ['.js', '.vue'],
        alias: {
          vue$: 'vue/dist/vue',
          components: path.resolve(__dirname, './ClientApp/components'),
          utils: path.resolve(__dirname, './ClientApp/utils'),
          api: path.resolve(__dirname, './ClientApp/store/api'),
          assets: path.resolve(__dirname, './ClientApp/assets'),
          mixins: path.resolve(__dirname, './ClientApp/mixins')
        }
      },
      output: {
        path: path.join(__dirname, bundleOutputDir),
        filename: '[name].js',
        chunkFilename: '[name].chunk.bundle.js',
        publicPath: '/dist/'
      },
      module: {
        rules: [
          { test: /\.vue$/, include: /ClientApp/, use: 'vue-loader' },
          { test: /\.js$/, include: /ClientApp/, use: 'babel-loader' },
          { test: /\.css$/, use: ['style-loader', 'css-loader'] },
          { test: /\.scss$/, use: ['style-loader', 'css-loader', 'sass-loader'] },
          { test: /\.(png|jpg|jpeg|gif|svg|png)$/, use: 'url-loader?limit=25000' },
          {
            test: /\.(woff(2)?|ttf|eot)(\?v=\d+\.\d+\.\d+)?$/,
            use: [
              {
                loader: 'file-loader',
                options: {
                  name: '[name].[ext]',
                  outputPath: 'fonts/'
                }
              }
            ]
          }
        ]
      },
      plugins: [
        new VueLoaderPlugin(),
        new MiniCssExtractPlugin({
          filename: '[name].css'
        }),
        new HtmlWebpackPlugin({
          filename: path.resolve(__dirname, bundleOutputDir, 'index.html'),
          template: path.resolve(__dirname, 'ClientApp/index.html')
        })
      ]
    }
  ];
};
