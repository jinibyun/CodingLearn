const path = require('path');
module.exports = {
	 entry: './src/index.ts',
	// entry: ['./src/index.ts', './src/01basic.ts'], // NOTE: can set more than two entry files
	// entry: './src/01fromEvent.ts',
  // entry: './src/02Operator.ts',
  // entry: './src/02-1Op_Combination_CombineAll.ts',
  // entry: './src/03OP_Creation_Ajax.ts',
  // entry: './src/04OP_Creation_Create.ts',
  // entry : './src/05OP_Creation_Defer.ts',
  // entry : './src/06OP_Creation_Empty.ts',
  // entry : './src/07OP_Creation_From.ts',
  // entry : './src/08OP_Creation_FromEvent.ts',
  // entry : './src/09OP_Creation_Generate.ts',
  // entry : './src/10OP_Creation_Interval.ts',
  // entry : './src/11OP_Creation_Of.ts',
  // entry : './src/12OP_Creation_Range.ts',
  // entry: './src/13OP_Creation_Throw.ts',
  // entry: './src/14OP_Creation_Timer.ts',
  // entry: './src/15OP_Filtering_debounceTime.ts',
  // entry : './src/16OP_Filtering_distinctUntilChanged.ts',
  // entry : './src/17OP_Filtering_Filter.ts',
  // entry : './src/18OP_Filtering_Take.ts',
  // entry : './src/19OP_Filtering_TakeUntil.ts',
  // entry: './src/20OP_Transformation_buffer.ts',
  // entry: './src/21OP_Transformation_bufferTime.ts',
  // entry: './src/22OP_Transformation_concatMap.ts',
  // entry : './src/23OP_Transformation_Map.ts',
  // entry: './src/24OP_Transformation_mergeMap.ts',
  // entry: './src/26OP_transformation_SwitchMap.ts',
  // entry : './src/27Subject_Subject.ts',
    devtool: 'inline-source-map',
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          use: 'ts-loader',
          exclude: /node_modules/
        }
      ]
    },
    resolve: {
      extensions: [ '.tsx', '.ts', '.js' ]
    },
    output: {
      filename: 'bundle.js',
      path: path.resolve(__dirname, 'dist')
    }
};