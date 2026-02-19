let a=10
for (let i=1;i <=a;i++){
    let result = i>=0 ? `${i} is positive` : `${i} is negative`;
    console.log(result);
    if (i%2==0){
        console.log(`${i} is even`)
    }
    else{
        console.log(`${i} is odd`)
    }
}
for (let i=1;i <10;i++){
    console.log(i)
}