const snakeArray = (snakeStart) => {
    const results = [];
  for (let i = 0; i < 6; i++) {
      results.push([]);
    }
    let counter = snakeStart;
    let startColumn = 0;
    let endColumn = 6;
    let startRow = 0;
    let endRow = 5;
    while (startColumn <= endColumn && startRow <= endRow) {
      // Top row
      for (let i = startColumn; i <= endColumn; i++) {
        results[startRow][i] = counter;
        counter++;
      }
      startRow++;
  // Right column
      for (let i = startRow; i <= endRow; i++) {
        results[i][endColumn] = counter;
        counter++;
      }
      endColumn--;
  // Bottom row
      for (let i = endColumn; i >= startColumn; i--) {
        results[endRow][i] = counter;
        counter++;
      }
      endRow--;
  // start column
      for (let i = endRow; i >= startRow; i--) {
        results[i][startColumn] = counter;
        counter++;
      }
      startColumn++;
    }
  return results;
  }

module.exports = snakeArray;
 