float x1, y1, z1; 
float x2, y2, z2; 
float x3, y3, z3; 
float x4, y4, z4; 

float[] temp; 

void setup() 
{ 
  size(1200, 600, P3D);
  
  x1 = 0; 
  y1 = 0; 
  z1 = 200; 

  x2 = 200; 
  y2 = 0; 
  z2 = 0; 

  x3 = 0; 
  y3 = 0; 
  z3 = 200; 

  x4 = 0; 
  y4 = 200; 
  z4 = 0; 
} 

int click;
void draw() 
{ 
  background(255); 
  if (click == 0)
  {
    pushMatrix();
    textSize(32);
    fill(255, 0 ,0);
    text("Coons surface:", 20 , 40);
    
    camera(mouseX, mouseY, (height/2) / tan(PI/6), width/2, height/2, 0, 0, 1, 0);
    translate(width/2, height/2, 0);
    stroke(0);
    line(-width/2,0,width/2,0);
    line(0,-height/2,0,height/2);
    beginShape();
    vertex(0,0,width);
    vertex(0,0,-width);
    vertex(0,0,width);
    endShape();

    stroke(255, 0, 0);
    strokeWeight(2);
    scale(1.3);

    for(float u = 0; u < 1; u += 0.05) 
    { 
       for(float w = 0; w < 1; w += 0.05) 
       { 
          temp = Q(u,w); 
          point(temp[0], temp[1], temp[2]);
       }  
    } 
    popMatrix();
  }
  if (click == 1) 
  {
    pushMatrix();
    textSize(32);
    fill(255, 0 ,0);
    text("Projection on x = 0:", 20 , 40);
    
    camera(mouseX, mouseY, (height/2) / tan(PI/6), width/2, height/2, 0, 0, 1, 0);
    translate(width/2, height/2, 0);
    stroke(0);
    line(-width/2,0,width/2,0);
    line(0,-height/2,0,height/2);
    beginShape();
    vertex(0,0,width);
    vertex(0,0,-width);
    vertex(0,0,width);
    endShape();

    stroke(255, 0, 0);
    strokeWeight(2);
    scale(1.3);

   for(float u = 0; u < 1; u += 0.05) 
    { 
       for(float w = 0; w < 1; w += 0.05) 
       { 
          temp = Q(u,w); 
          point(0, temp[1], temp[2]);
       }  
    } 
    popMatrix();  
  }
  if (click == 2)
  {
    pushMatrix();
    textSize(32);
    fill(255, 0 ,0);
    text("Projection on y = 0:", 20 , 40);
    
    camera(mouseX, mouseY, (height/2) / tan(PI/6), width/2, height/2, 0, 0, 1, 0);
    translate(width/2, height/2, 0);
    stroke(0);
    line(-width/2,0,width/2,0);
    line(0,-height/2,0,height/2);
    beginShape();
    vertex(0,0,width);
    vertex(0,0,-width);
    vertex(0,0,width);
    endShape();

    stroke(255, 0, 0);
    strokeWeight(2);
    scale(1.3);
 
   for(float u = 0; u < 1; u += 0.05) 
    { 
       for(float w = 0; w < 1; w += 0.05) 
       { 
          temp = Q(u,w); 
          point(temp[0], 0, temp[2]);
       }  
    } 
    popMatrix();
  }
  if (click == 3)
  {
    pushMatrix();
    textSize(32);
    fill(255, 0 ,0);
    text("Projection on z = 0:", 20 , 40);
    noFill();
    camera(mouseX, mouseY, (height/2) / tan(PI/6), width/2, height/2, 0, 0, 1, 0);
    translate(width/2, height/2, 0);
    stroke(0);
    line(-width/2,0,width/2,0);
    line(0,-height/2,0,height/2);
    beginShape();
    vertex(0,0,width);
    vertex(0,0,-width);
    vertex(0,0,width);
    endShape();
    
    stroke(255, 0, 0);
    strokeWeight(2);
    scale(1.3);
   
    for(float u = 0; u < 1; u += 0.05) 
    { 
       for(float w = 0; w < 1; w += 0.05) 
       { 
          temp = Q(u,w); 
          point(temp[0], temp[1], 0);
       }  
    } 
    popMatrix();
  } 
}
  
void mousePressed()
{
  click += 1;
  if (click > 3)
  {
    click = 0;
  }
}

float[] P0w(float t) 
{ 
   float[] res = { x1 + t * (x2 - x1), y1 + t * (y2 - y1), z1 + t * (z2 - z1)}; 
   return res; 
} 

float[] P1w(float t) 
{ 
   float[] res = { x3 + t * (x4 - x3), y3 + t * (y4 - y3), z3 + t * (z4 - z3)}; 
   return res; 
} 

float[] Pu0(float t) 
{ 
   float[] res = { x1 + t * (x2 - x1), y1 + t * (y2 - y1), z1 + t * (z2 - z1)}; 
   return res; 
} 

float[] Pu1(float t) 
{ 
   float[] res = { x3 + t * (x4 - x3), y3 + t * (y4 - y3), z3 + t * (z4 - z3)}; 
   return res; 
} 

float[] Q(float u, float w) 
{      
   float[] p00 = {0, 0, 0};
   float[] p01 = {0, 0, 0};
   float[] p10 = {0, 0, 0};
   float[] p11 = {0, 0, 0};       
 
   float[] p0w = P0w(w); 
   float[] p1w = P1w(w); 
   float[] p0u = Pu0(u); 
   float[] p1u = Pu1(u); 
   
   float[] res = {p0u[0] * (1 - w) + p1u[0] * w + p0w[0] * (1 - u) + p1w[0] * u - p00[0] * (1-u) * (1-w) - p01[0] * (1-u) * w - p10[0] * u * (1-w) - p11[0] * u * w,
                  p0u[1] * (1 - w) + p1u[1] * w + p0w[1] * (1 - u) + p1w[1] * u - p00[1] * (1-u) * (1-w) - p01[1] * (1-u) * w - p10[1] * u * (1-w) - p11[1] * u * w,
                  p0u[2] * (1 - w) + p1u[2] * w + p0w[2] * (1 - u) + p1w[2] * u - p00[2] * (1-u) * (1-w) - p01[2] * (1-u) * w - p10[2] * u * (1-w) - p11[2] * u * w}; 
  // println(res[0], res[1], res[2]);
   return res; 
}