const webpack = require('webpack');
const path = require('path');
const webpackMerge = require('webpack-merge');
const VueLoaderPlugin = require('vue-loader/lib/plugin');
var HtmlWebpackPlugin = require('html-webpack-plugin');

const bundleOutputDir = './wwwroot/dist';

const modeConfig = env => require(`./webpack/webpack.${env}`)(env);
const presetConfig = require('./webpack/loadPresets');

module.exports = ({ mode, presets } = { mode: 'production', presets: [] }) => {
  console.log('Building for \x1b[33m%s\x1b[0m', mode);
  
  return webpackMerge(
    {
      mode,
      resolve: {
        extensions: ['.js', '.vue'],
        alias: {
          components: path.resolve(__dirname, './ClientApp/components'),
          utils: path.resolve(__dirname, './ClientApp/utils'),
          api: path.resolve(__dirname, './ClientApp/store/api'),
          assets: path.resolve(__dirname, './ClientApp/assets'),
          mixins: path.resolve(__dirname, './ClientApp/mixins'),
          locales: path.resolve(__dirname, './ClientApp/locales')
        }
      },
      entry: { main: './ClientApp/boot-app.js' },
      output: {
        path: path.join(__dirname, bundleOutputDir),
        filename: '[name].[hash].bundle.js'
      },
      module: {
        rules: [
          { test: /\.vue$/, include: /ClientApp/, use: 'vue-loader' },
          { test: /\.js$/, include: /ClientApp/, use: 'babel-loader' },
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
        new webpack.ProgressPlugin(),
        new HtmlWebpackPlugin(),
        new VueLoaderPlugin(),
        new HtmlWebpackPlugin({
          filename: path.resolve(__dirname, bundleOutputDir, 'index.html'),
          template: path.resolve(__dirname, 'ClientApp/index.html')
        })
      ]
    },
    modeConfig(mode),
    presetConfig({ mode, presets })
  );
};
