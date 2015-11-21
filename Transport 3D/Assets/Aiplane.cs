public class Airplane  {
	public int x, y;
	//set starting position in x,y coordinates
	//public thing startingPlace = (0,8);
	public int xMoveDir, yMoveDir;

	public void SetMoveDirection (int x, int y) {
		xMoveDir = x;
		yMoveDir = y;
	}

	public void MoveAirplane () {
		x += xMoveDir;
		y += yMoveDir;
		xMoveDir = 0;
		yMoveDir = 0;
	}//Thanks Isaiah :)  <lines 7-18>	

	public bool activeAirplane = true;
	//track if an airplane is active or not
	//if airplane is active, make it red
	//put the airplane in the top left corner

	/*public int cargo, cargoCapacity;*/
	//cargo max capacity of 90, be <=90
	public int cargo = 0;
	public int cargoCapacity = 90;
	//start with no cargo int cargo = 0;

}
