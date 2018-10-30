module.exports = {
  root: true,
  parser: 'babel-eslint',
  parserOptions: {
    sourceType: 'module'
  },
  // https://github.com/feross/standard/blob/master/RULES.md#javascript-standard-style
  extends: 'standard',
  // required to lint *.vue files
  plugins: [
    'html'
  ],
  // add your custom rules here
  'rules': {
    'indent': 0,
    'quotes': 0,
    'space-before-blocks':0,
    'space-before-function-paren':0,
    'semi':0,
    'block-spacing':0,
    'key-spacing':0,
    'object-curly-spacing':0,
    'no-multiple-empty-lines':0,
    'padded-blocks':0,
    'no-trailing-spaces':0,
    'brace-style':0,
    'keyword-spacing': 0,
    // allow paren-less arrow functions
    'arrow-parens': 0,
    // allow async-await
    'generator-star-spacing': 0,
    // allow debugger during development
    'no-debugger': process.env.NODE_ENV === 'production' ? 2 : 0
  }
}
