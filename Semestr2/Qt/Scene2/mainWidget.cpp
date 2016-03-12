#include "mainWidget.h"

#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGraphicsRectItem>
#include <QtWidgets/QPushButton>
#include <QDir>
#include <QFileDialog>

Widget::Widget(QWidget *parent)
    : QWidget(parent)
{
    mView = new QGraphicsView(&mScene, this);
    const auto layout = new QGridLayout(this);
    layout->addWidget(mView,0,0,1,3);

    const auto rectButton = new QPushButton("Add rect", this);
    connect(rectButton, SIGNAL(clicked(bool)), this, SLOT(addRect()));
    layout->addWidget(rectButton, 1,0);

    const auto circleButton = new QPushButton("Add circle", this);
    connect(circleButton, SIGNAL(clicked(bool)), this, SLOT(addCircle()));
    layout->addWidget(circleButton, 1, 1);

    const auto lineButton = new QPushButton("Add line", this);
    connect(lineButton, SIGNAL(clicked(bool)), this, SLOT(addLine()));
    layout->addWidget(lineButton, 1, 2);

    const auto saveButton = new QPushButton("Save picture", this);
    connect(saveButton, SIGNAL(clicked(bool)), this, SLOT(saveScene()));
    layout->addWidget(saveButton, 2, 0, 1, 3);
}

void Widget::addRect()
{
    const auto rect = mScene.addRect(0,0,30,30);
    rect->setFlag(QGraphicsItem::ItemIsMovable);
    rect->setFlag(QGraphicsItem::ItemIsSelectable);
}

void Widget::addCircle()
{
    const auto circle = mScene.addEllipse(0, 0, 30, 30);
    circle->setFlag(QGraphicsItem::ItemIsMovable);
    circle->setFlag(QGraphicsItem::ItemIsSelectable);
}

void Widget::addLine()
{
    const auto line = mScene.addLine(0, 0, 30, 30);
    line->setFlag(QGraphicsItem::ItemIsMovable);
    line->setFlag(QGraphicsItem::ItemIsSelectable);
}

void Widget::saveScene()
{
    QImage image(mView->width(), mView->height(), QImage::Format_ARGB32_Premultiplied);
    QPainter painter(&image);
    mView->render(&painter);
    QString initialPath = QDir::currentPath() + tr("/picture.png");
    QString fileName = QFileDialog::getSaveFileName(this, tr("Save As"), initialPath);
    image.save(fileName);
}

Widget::~Widget()
{

}
